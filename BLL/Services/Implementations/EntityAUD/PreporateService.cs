using AutoMapper;
using BLL.Services.Interfaces.EntityAUD;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using ML.Mapper;
using ML.Models;

namespace BLL.Services.Implementations;

public class PreporateService : IPreporateService
{
    private readonly IPreporateRepository _preporateRepository;
    private readonly IMapper _mapper;
    public PreporateService(IPreporateRepository preporateRepository, IMapper mapper)
    {
        _preporateRepository = preporateRepository;
        _mapper = mapper;
    }
    string GetFileExtension(IFormFile file)
    {
        var fileName = file.FileName;

        var fileExtension = Path.GetExtension(fileName);

        return fileExtension;
    }
    async Task<byte[]> ConvertToByteArray(IFormFile file)
    {
        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
    public async Task<bool> Add(PreporateModel model)
    {
        if (model == null)
            return false;

        Console.WriteLine("123"+(model.ImageFile==null).ToString());
        if (model.ImageFile!=null)
        {
            Console.WriteLine(GetFileExtension(model.ImageFile));
            if (GetFileExtension(model.ImageFile)==".jpg"||GetFileExtension(model.ImageFile)==".png")
            {
                var res = ConvertToByteArray(model.ImageFile);
                await res;
                model.Image = res.Result;
            }
            else
            {
                return false;
            }
        }

        var mapped = _mapper.Map<PreporateModel, Preporate>(model);
        if (mapped==null)
            return false;
        if (model.ImageFile == null)
        {
            mapped.Image = null;
        }
        _preporateRepository.Add(mapped);
        return true;
        
    }

    public async Task<bool> Update(PreporateModel model)
    {
        if (model.ImageFile!=null)
        {
            if (GetFileExtension(model.ImageFile)==".jpg"||GetFileExtension(model.ImageFile)==".png")
            {
                var res = ConvertToByteArray(model.ImageFile);
                await res;
                model.Image = res.Result;
            }
            else
            {
                return false;
            }
        }
        
        if (model == null)
            return false;
        if (_preporateRepository.GetById(model.Id) == null)
            return false;
        
        var mapped = _mapper.Map<PreporateModel, Preporate>(model);
        if (model.ImageFile == null)
        {
            mapped.Image = null;
        }
        _preporateRepository.UpdateById(model.Id, mapped);
        return true;
    }

    public async Task<bool> Delete(int Id)
    {
        var entity = _preporateRepository.GetById(Id);
        if (entity==null)
        {
            return false;
        }
        _preporateRepository.DeleteById(Id);
        return true;
    }

    public async Task<PreporateModel> GetById(int Id)
    {
        var type = _preporateRepository.GetById(Id);
        var vm = _mapper.Map<Preporate, PreporateModel>(type);
        return vm;
    }
}