using App.Core;
using App.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deneme.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {

        private IService<News> _newsService;
        private readonly ILogger<NewsController> _logger;

        public NewsController(IService<News> newsService, ILogger<NewsController> logger)
        {
            _newsService = newsService;
            _logger = logger;
        }


        [HttpGet]
        public List<News> Get()
        {

            try
            {
                return _newsService.GetAll().Where(x=> x.NewsStatus == 1).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("hata" + ex.Message);
                throw new Exception("Haber listesi çekilemedi News");
            }

        }

        [HttpGet]
        [Route("AllNews")]
        public List<News> GetAll()
        {

            try
            {
                return _newsService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError("hata" + ex.Message);
                throw new Exception("Haber listesi çekilemedi News");
            }

        }


        [HttpGet("{id}")]
        public News Get(int id)
        {
            try
            {
                return _newsService.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("hata" + ex.Message);
                throw new Exception("id çekilemedi News");
            }
            
        }

        [HttpPost]
        public int Post([FromBody] News kayit)
        {
            try
            {
                kayit.NewsStatus = 1;
                return _newsService.Save(kayit);
            }
            catch (Exception ex)
            {
                _logger.LogError("hata" + ex.Message);
                throw new Exception("kayıt yapılamadı News");
            }
            
        }

        [HttpPut]
        public int Put([FromBody] News kayit)
        {
            try
            {
                kayit.NewsStatus = 1;
                return _newsService.Update(kayit);
            }
            catch (Exception ex)
            {
                _logger.LogError("hata" + ex.Message);
                throw new Exception("Kayıt güncellenemedi News");
            }
            
        }

        [HttpDelete]
        public void DeleteStatus(int id)
        {
            try
            {
                var delete = _newsService.GetById(id);
                delete.NewsStatus = 2;
                _newsService.Delete(delete);
            }
            catch (Exception ex)
            {
                _logger.LogError("hata" + ex.Message);
                throw new Exception("Id'ye göre kayıt silinemedi News");
            }

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _newsService.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("hata" + ex.Message);
                throw new Exception("Id'ye göre kayıt silinemedi News");
            }
            
        }
    }
}
