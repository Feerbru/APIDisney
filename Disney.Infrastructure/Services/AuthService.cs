using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Disney.Core.DTOs.UserDto;
using Disney.Core.Entities;
using Disney.Core.Interfaces.Repository;
using Disney.Infrastructure.Services.Interfaces;

namespace Disney.Infrastructure.Services
{
    public class AuthService : IAuthService
    {

        private readonly IAuthRepository _repository;
        private readonly IMapper _mapper;

        public AuthService(IAuthRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<User> GetLoginByCredentials(UserLogin login)
        {
            //CreatePassword(login.Password,out var passwordHash, out var passwordSalt);

            var entityM = _mapper.Map<User>(login);
            //entityM.PasswordHash = passwordHash;
            //entityM.PasswordSalt = passwordSalt;
            
            //login.Password = Encrypt(login.Password);
            var entity = await _repository.GetLoginByCredentials(entityM);

            //entity.Password = Decrypt(entity.Password);
            
            if (entity == null) return null;
            if (!VerifyPasswordHash(login.Password, entity.PasswordHash, entity.PasswordSalt)) return null;
            
            return entity;
        }

        public async Task Register(UserDto userDto)
        {
            
            CreatePassword(userDto.Password, out var passwordHash, out var passwordSalt);
            
            var entity = _mapper.Map<User>(userDto);
            
            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;
            
            //var entity = _mapper.Map<User>(userDto);
            //entity.Password = Encrypt(entity.Password);
            await _repository.Add(entity);
        }

        public async Task<bool> GetUserAndEmail(UserDto userDto)
        {
            var entity = _mapper.Map<User>(userDto);
            entity = await _repository.GetUserAndEmail(entity);
            
            if (entity != null)
            {
                return true;
            }

            return false;
        }
        /*
        public string Encrypt(string password)
        {
            string result = String.Empty;
            byte[] encrypted = System.Text.Encoding.UTF8.GetBytes(password);
            result = Convert.ToBase64String(encrypted);

            return result;
        }

        public string Decrypt(string password)
        {
            var result = string.Empty;
            byte[] decrypted = Convert.FromBase64String(password);
            result = System.Text.Encoding.Unicode.GetString(decrypted, 0, decrypted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decrypted);
            
            return result;
        }*/
        
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }

            return true;
        }

        private void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}