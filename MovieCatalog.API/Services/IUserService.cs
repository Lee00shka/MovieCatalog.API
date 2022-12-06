
using MovieCatalog.API.Models;
using MovieCatalog.API.Models.Views;

namespace MovieCatalog.API.Services
{
    public interface IUserService
    {
        Task<ProfileModel> Get(string userId);
        Task Put(string userId, ProfileModel profileModel);
    }
    public class UserService: IUserService
    {
        private readonly Context _context;
        private readonly ISupportService _supportService;
        public UserService(Context context, ISupportService supportService)
        {
            _context=context;
            _supportService=supportService;
        }

        public async Task<ProfileModel> Get(string userId)
        {
            var user = _context.UserEntitys.FirstOrDefault(x=> x.Id == userId);
            return new ProfileModel
            {
                Id = user.Id,
                NickName = user.NickName,
                Email = user.Email,
                AvatarLink = user.AvatarLink,
                Name = user.Name,
                BirthDate = user.BirthDate,
                Gender = user.Gender
            };
        }
        public async Task Put(string userId, ProfileModel profileModel)
        {
            var user = _context.UserEntitys.FirstOrDefault(x=> x.Id == userId);
            //user.Id = profileModel.Id;
            //user.NickName = profileModel.NickName;
            user.Email = profileModel.Email;
            user.AvatarLink = profileModel.AvatarLink;
            user.Name = profileModel.Name;
            user.BirthDate = profileModel.BirthDate;
            user.Gender = profileModel.Gender;
            _context.UserEntitys.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
