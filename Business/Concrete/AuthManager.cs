using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entity.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITeacherService teacherService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, ITeacherService teacherService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            this.teacherService = teacherService;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }


        [ValidationAspect(typeof(TeacherValidator))]
        public IDataResult<User> RegisterAsTeacher(TeacherForRegisterDto teacherForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(teacherForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = teacherForRegisterDto.Email,
                FirstName = teacherForRegisterDto.FirstName,
                LastName = teacherForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);

            var newUser = _userService.GetByMail(teacherForRegisterDto.Email);

            Teacher teacher = new Teacher()
            {
                UserId = newUser.Id,
                Profession = teacherForRegisterDto.Email,
                InformationVideo = teacherForRegisterDto.InformationVideo,
                Instagram = teacherForRegisterDto.Instagram,
                TiktTok = teacherForRegisterDto.TiktTok,
                YouTube = teacherForRegisterDto.YouTube
            };
            teacherService.Add(teacher);

            return new SuccessDataResult<User>(user, Messages.SuccessfulLoginForTeacher);




        }
    }
}
