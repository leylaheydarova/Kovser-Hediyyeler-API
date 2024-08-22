using AutoMapper;
using KovserHediyyeler.Core.Entities;
using KovserHediyyeler.Core.Repositories.Abstractions.Departments;
using KovserHediyyeler.Service.Dtos.Departments;
using KovserHediyyeler.Service.Responses;
using KovserHediyyeler.Service.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Service.Services.Concretes
{
    public class DepartmentService : IDeparmentService
    {
        private readonly IDepartmentReadRepository _readrepository;
        private readonly IDepartmentWriteRepository _writeRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentReadRepository readrepository, IDepartmentWriteRepository writeRepository, IMapper mapper)
        {
            _readrepository = readrepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> CreateAsync(DepartmentPostDto dto)
        {
            Department department = _mapper.Map<Department>(dto);
            _writeRepository.AddAsync(department);
            return new ApiResponse { StatusCode = 201, StatusMessage = "Created Successfully!" };
        }

        public async Task<ApiResponse> DeleteAsync(string id)
        {
            Department department = await _readrepository.GetWhere(x => x.ID.ToString() == id);
            if(department == null)
            {
                return new ApiResponse { StatusCode = 404, StatusMessage = "NOT FOUND!" };
            }
            _writeRepository.DeleteSoft(department);
            await _writeRepository.SaveAsync();
            return new ApiResponse { StatusCode = 200, StatusMessage = "Deleted Temporarily!" };
        }

        public async Task<ApiResponseWithData> GetAllAsync()
        {
            var query =  _readrepository.GetAllWhere(x => !x.isDeleted, false);
            List<DepartmentGetDto> dtos = new List<DepartmentGetDto>();
            dtos = await query.Select(x => new DepartmentGetDto {
                Id = x.ID.ToString(), 
                Name = x.Name, 
                Description = x.Description, 
                Phone = x.Phone, 
                Facebook = x.Facebook, 
                Instagram = x.Instagram, 
                YouTube = x.YouTube, 
                TikTok = x.TikTok })
                .ToListAsync();
            return new ApiResponseWithData { StatusCode = 200, Datas = dtos };
        }
        

        public async Task<ApiResponseWithData> GetAsync(string id)
        {
            Department department =await _readrepository.GetWhere(x=>x.ID.ToString() == id);
            if(department == null)
            {
                return new ApiResponseWithData { StatusCode = 404, StatusMessage = "NOT FOUND!" };
            }
            DepartmentGetDto dto = _mapper.Map<DepartmentGetDto>(department);
            return new ApiResponseWithData { StatusCode = 200, Datas = department };
        }

        public async Task<ApiResponse> RemoveAsync(string id)
        {
            Department department = await _readrepository.GetWhere(x => x.ID.ToString() == id);
            if (department == null)
            {
                return new ApiResponse { StatusCode = 404, StatusMessage = "NOT FOUND!" };
            }
            _writeRepository.Delete(department);
            await _writeRepository.SaveAsync();
            return new ApiResponse { StatusCode = 200, StatusMessage = "Removed Permanently!" };
        }

        public async Task<ApiResponse> UpdateAsync(string id, DepartmentPutDto dto)
        {
            Department department = await _readrepository.GetWhere(x => x.ID.ToString() == id);
            if (department == null)
            {
                return new ApiResponse { StatusCode = 404, StatusMessage = "NOT FOUND!" };
            }
            department.Name = dto.Name;
            department.Description = dto.Description;
            department.Phone = dto.Phone;
            department.Facebook = dto.Facebook;
            department.Instagram = dto.Instagram;
            department.YouTube = dto.YouTube;
            department.TikTok = dto.TikTok;
            _writeRepository.Update(department);
            await _writeRepository.SaveAsync();
            return new ApiResponse { StatusCode = 200, StatusMessage = "Updated Successfully!" };
        }
    }
}
