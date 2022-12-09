using App.Core;
using App.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deneme.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        private IService<Writer> _writerService;
        private readonly ILogger<NewsController> _logger;

        public WritersController(IService<Writer> writerService, ILogger<NewsController> logger)
        {
            _writerService = writerService;
            _logger = logger;
        }


        [HttpGet]
        public List<Writer> Get()
        {

            try
            {
                return _writerService.GetAll().Where(x => x.WriterStatus == 1).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("hata" + ex.Message);
                throw new Exception("Liste çekilemedi Writer");
            }

        }

        [HttpGet]
        [Route("AllWriters")]
        
        public List<Writer> GetAll()
        {

            try
            {
                return _writerService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError("hata" + ex.Message);
                throw new Exception("Liste çekilemedi Writer");
            }

        }
      
        [HttpGet("{id}")]
        public Writer Get(int id)
        {
            try
            {
                return _writerService.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("hata" + ex.Message);
                throw new Exception("yazar id çekilemedi Writer");
            }

        }

        [HttpPost]
        public int Post([FromBody] Writer yazar)
        {
            try
            {
                yazar.WriterStatus = 1;
                return _writerService.Save(yazar);
            }
            catch (Exception ex)
            {
                _logger.LogError("hata" + ex.Message);
                throw new Exception("kayıt yapılamadı Writer");
            }

        }

        [HttpPut]
        public int Put([FromBody] Writer yazar)
        {
            try
            {
                yazar.WriterStatus = 1;
                return _writerService.Update(yazar);
            }
            catch (Exception ex)
            {
                _logger.LogError("hata" + ex.Message);
                throw new Exception("Kayıt güncellenemedi Writer");
            }

        }

        [HttpDelete]
        public void DeleteStatus(int id)
        {
            try
            {
                var delete = _writerService.GetById(id);
                delete.WriterStatus = 2;
                _writerService.Delete(delete);
            }
            catch (Exception ex)
            {
                _logger.LogError("hata" + ex.Message);
                throw new Exception("Id'ye göre kayıt silinemedi Writer");
            }

        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _writerService.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("hata" + ex.Message);
                throw new Exception("Id'ye göre kayıt silinemedi Writer");
            }

        }
    }
}

