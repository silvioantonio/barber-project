using AutoMapper;
using P = MeuBarbeiro.API.Models.Provider;
using MeuBarbeiro.API.Data.ValueObjects;
using MeuBarbeiro.API.Repository.Provider;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Drawing;
using System.Drawing.Imaging;

namespace MeuBarbeiro.API.Services.Provider
{
    public class ProviderService : IProviderService
    {
        private const string Tags = "backend_PhotoAlbum";

        private readonly IMapper _mapper;
        private readonly Cloudinary _cloudinary;
        private readonly IProviderRepository _providerRepository;

        public ProviderService(IProviderRepository providerRepository, IMapper mapper, Cloudinary cloudinary)
        {
            _mapper = mapper;
            _providerRepository = providerRepository;
            _cloudinary = cloudinary;
        }

        public async Task<ProviderVO> Create(ProviderVO providerVO)
        {
            if (providerVO.Email != null)
            {
                var hasProvider = await _providerRepository.FindByEmail(providerVO.Email);

                if (hasProvider)
                {
                    throw new ArgumentException("Email já cadastrado!");
                }
            }

            if(providerVO.Avatar != null)
            {
                var result = await _cloudinary.UploadAsync(new ImageUploadParams
                {
                    File = new FileDescription(providerVO.Avatar?.FileName, providerVO?.Avatar?.OpenReadStream()),
                    Tags = Tags,
                    AssetFolder = "meu_barbeiro",
                    Folder = "meu_barbeiro",
                }).ConfigureAwait(false);

                if(result != null)
                {
                    providerVO.AvatarId = (result.SecureUrl ?? result.Url).ToString();
                }
            }

            var provider = _mapper.Map<P.Provider>(providerVO);

            provider.CreatedAt = DateTime.Now;

            var response = await _providerRepository.Create(provider);
            return _mapper.Map<ProviderVO>(response);
        }

        public async Task<bool> Delete(long id)
        {
            return await _providerRepository.Delete(id);
        }

        public async Task<IEnumerable<ProviderVO>> FindAll()
        {
            var response = await _providerRepository.FindAll();
            var list = response.Select(provider => _mapper.Map<ProviderVO>(provider));
            return list;
        }

        public async Task<ProviderVO> FindById(long id)
        {
            var response = await _providerRepository.FindById(id);
            return _mapper.Map<ProviderVO>(response);
        }

        public async Task<ProviderVO> Update(ProviderVO providerVO)
        {
            if (providerVO.Id <= 0)
            {
                throw new ArgumentException("O id é invalido!");
            }

            var provider = _mapper.Map<P.Provider>(providerVO);
            var response = await _providerRepository.Update(provider);
            return _mapper.Map<ProviderVO>(response);
        }
    }
}
