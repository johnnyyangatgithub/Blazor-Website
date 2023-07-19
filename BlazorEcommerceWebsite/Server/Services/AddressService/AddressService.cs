using System;

namespace BlazorEcommerceWebsite.Server.Services.AddressService
{
    public class AddressService : IAddressService
    {
        private readonly DataContext _dataContext;
        private readonly IAuthService _authService;
        public AddressService( DataContext dataContext, IAuthService authService )
        {
            _dataContext = dataContext;
            _authService = authService;
        }

        public async Task<ServiceResponse<Address>> AddOrUpdateAddress(Address address)
        {
            var response = new ServiceResponse<Address>();
            var dbAddress = (await GetAddress()).Data;
            if(dbAddress == null)
            {
                address.UserId = _authService.GetUserId();
                _dataContext.Addresses.Add( address );
                response.Data = address;
            }
            else
            {
                dbAddress.FirstName = address.FirstName;
                dbAddress.LastName = address.LastName;
                dbAddress.Street = address.Street;
                dbAddress.City = address.City;
                dbAddress.State = address.State;
                dbAddress.Zip = address.Zip;
                dbAddress.Country = address.Country;

            }

            await _dataContext.SaveChangesAsync();
            return response;
        }

        public async Task<ServiceResponse<Address>> GetAddress()
        {
            int userId = _authService.GetUserId();
            var address = await _dataContext.Addresses.FirstOrDefaultAsync( a => a.UserId == userId );
            return new ServiceResponse<Address> { Data = address };
        }
    }
}

