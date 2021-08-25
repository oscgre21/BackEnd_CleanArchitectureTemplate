using System;
using System.Collections.Generic;
 
using Microsoft.AspNetCore.Mvc; 

namespace BaseCleanArchitecture.API.Controllers
{
    //[Produces("application/json")]
    [Route("api/Inventory")]
    public class InventarioController : Controller
    {
        private IMaintenance _maintenance;

        public InventarioController(IMaintenance maintenance)
        {
            _maintenance = maintenance;
        } 
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
         
        [HttpGet]
        [Route("getGenericID")]
        public IActionResult getGenericID(string tipo_serie_doc)
        {
            var model = _maintenance.getUnicID(tipo_serie_doc);
            return Ok(model);
        }

        [HttpGet]
        [Route("getDeparments")]
        public IActionResult getDeparment()
        {

            var model = _maintenance.getDepartments(this.getQueryFilterHeader());
            return Ok(model);
        }

        [HttpGet]
        [Route("getDeparmentByID")]
        public IActionResult getDeparmentByID(string ids)
        {
            // Console.WriteLine("ids->"+ ids);
            var model = _maintenance.getDeparmentByID(ids);
            return Ok(model);
        }

        [HttpGet]
        [Route("getProductByDepartment")]
        public IActionResult getProductByDepartment(string depto)
        {
            var model = _maintenance.getProductByDepartment(depto, this.getQueryFilterHeader());
            return Ok(model);
        }

        [HttpPost]
        [Route("saveDeparment")]
        public IActionResult saveDeparment([FromBody] dptosViewModel dptos)
        {
            ServiceResult model = new ServiceResult();
            if (ModelState.IsValid)
            {
                model = _maintenance.saveDpto(dptos);
            }
            return Ok(model);
        }

        //[Authorize]
        [HttpGet]
        [Route("getFamilies")]
        public IActionResult getFamilies()
        {
            var model = _maintenance.getFamilies(this.getQueryFilterHeader());
            //_maintenance.getAll<dptosViewModel,msfdptos>(this.getQueryFilterHeader());
            return Ok(model);
        }
        [HttpGet]
        [Route("getProductByFamilias")]
        public IActionResult getProductByFamilias(string id)
        {
            var model = _maintenance.getProductByFamilia(id, this.getQueryFilterHeader());
            return Ok(model);
        }

        [HttpGet]
        [Route("getFamilyByID")]
        public IActionResult getFamilyByID(string ids)
        {
            var model = _maintenance.getFamiliaByID(ids);
            return Ok(model);
        }
        [HttpPost]
        [Route("saveFamily")]
        public IActionResult saveFamily([FromBody] familiasViewModel obj)
        {
            ServiceResult model = new ServiceResult();
            if (ModelState.IsValid)
            {
                model = _maintenance.saveFamilia(obj);
            }
            return Ok(model);
        }
        [HttpGet]
        [Route("getMedidas")]
        public IActionResult getMedidas()
        {
            var model = _maintenance.getMedidas(this.getQueryFilterHeader());
            //_maintenance.getAll<dptosViewModel,msfdptos>(this.getQueryFilterHeader());
            return Ok(model);
        }
        [HttpGet]
        [Route("getMedidasByID")]
        public IActionResult getMedidasByID(string ids)
        {
            var model = _maintenance.getMedidasByID(ids);
            return Ok(model);
        }
        [HttpGet]
        [Route("getProductByMedidas")]
        public IActionResult getProductByMedidas(string id)
        {
            var model = _maintenance.getProductByMedidas(id, this.getQueryFilterHeader());
            return Ok(model);
        }
        [HttpPost]
        [Route("saveMedidas")]
        public IActionResult saveMedidas([FromBody] medidasViewModel obj)
        {
            ServiceResult model = new ServiceResult();
            if (ModelState.IsValid)
            {
                model = _maintenance.saveMedidas(obj);
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("getVendedores")]
        public IActionResult getVendedores()
        {
            var model = _maintenance.getVendedor(this.getQueryFilterHeader());
            //_maintenance.getAll<dptosViewModel,msfdptos>(this.getQueryFilterHeader());
            return Ok(model);
        }
        [HttpGet]
        [Route("getVendedorByID")]
        public IActionResult getVendedorByID(string ids)
        {
            var model = _maintenance.getVendedorByID(ids);
            return Ok(model);
        }

        [HttpPost]
        [Route("saveVendedor")]
        public IActionResult saveVendedor([FromBody] vendedorViewModel obj)
        {
            ServiceResult model = new ServiceResult();
            if (ModelState.IsValid)
            {
                model = _maintenance.saveVendedor(obj);
            }
            return Ok(model);
        }

        [HttpGet] 
        [Route("getAlmacen")]
        public IActionResult getAlmacen()
        {
            var model = _maintenance.getAlmacen(this.getQueryFilterHeader());
            return Ok(model);
        }
        [HttpGet]
        [Route("getAlmacenByID")]
        public IActionResult getAlmacenByID(string ids)
        {
            var model = _maintenance.getAlmacenByID(ids);
            return Ok(model);
        }
        [HttpPost]
        [Route("saveAlmacen")]
        public IActionResult saveAlmacen([FromBody] mstalmViewModel obj)
        {
            ServiceResult model = new ServiceResult();
            if (ModelState.IsValid)
            {
                model = _maintenance.saveAlmacen(obj);
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("getSubAlmacen")]
        public IActionResult getSubAlmacen()
        {
            var model = _maintenance.getSubAlmacen(this.getQueryFilterHeader());
            return Ok(model);
        }
        [HttpGet]
        [Route("getSubAlmacenByID")]
        public IActionResult getSubAlmacenByID(string ids)
        {
            var model = _maintenance.getSubAlmacenByID(ids);
            return Ok(model);
        }
        [HttpPost]
        [Route("saveSubAlmacen")]
        public IActionResult saveSubAlmacen([FromBody] subAlamcenViewModel obj)
        {
            ServiceResult model = new ServiceResult();
            if (ModelState.IsValid)
            {
                model = _maintenance.saveSubAlmacen(obj);
            }
            return Ok(model);
        }


        [HttpGet]
        [Route("getSessiones")]
        public IActionResult getSessiones()
        {
            var model = _maintenance.getSessiones(this.getQueryFilterHeader());
            return Ok(model);
        }
        [HttpGet]
        [Route("getSessionesByID")]
        public IActionResult getSessionesByID(string ids)
        {
            var model = _maintenance.getSessionesByID(ids);
            return Ok(model);
        }
        [HttpPost]
        [Route("saveSessiones")]
        public IActionResult saveSessiones([FromBody] sessionesViewModel obj)
        {
            ServiceResult model = new ServiceResult();
            if (ModelState.IsValid)
            {
                model = _maintenance.saveSessiones(obj);
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("getTramos")]
        public IActionResult getTramos()
        {
            var model = _maintenance.getTramos(this.getQueryFilterHeader());
            return Ok(model);
        }
        [HttpGet]
        [Route("getTramosByID")]
        public IActionResult getTramosByID(string ids)
        {
            var model = _maintenance.getTramosByID(ids);
            return Ok(model);
        }
        [HttpPost]
        [Route("saveTramos")]
        public IActionResult saveTramos([FromBody] coloresViewModel obj)
        {
            ServiceResult model = new ServiceResult();
            if (ModelState.IsValid)
            {
                model = _maintenance.saveTramos(obj);
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("getUbicacion")]
        public IActionResult getUbicacion()
        {
            var model = _maintenance.getUbicacion(this.getQueryFilterHeader());
            return Ok(model);
        }
        [HttpGet]
        [Route("getUbicacionByID")]
        public IActionResult getUbicacionByID(string ids)
        {
            var model = _maintenance.getUbicacionByID(ids);
            return Ok(model);
        }
        [HttpPost]
        [Route("saveUbicacion")]
        public IActionResult saveUbicacion([FromBody] ubicacionViewModel obj)
        {
            ServiceResult model = new ServiceResult();
            if (ModelState.IsValid)
            {
                model = _maintenance.saveUbicacion(obj);
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("getProductos")]
        public IActionResult getProductos()
        {
            var model = _maintenance.getProductos(this.getQueryFilterHeader());
            return Ok(model);
        }

        [HttpGet]
        [Route("getProductoListSelect")]
        public IActionResult getProductoListSelect()
        {
            var model = _maintenance.getProductItemSelect();
            return Ok(model);
        }


        [HttpGet]
        [Route("getProductosByID")]
        public IActionResult getProductosByID(string ids)
        {
            var model = _maintenance.getProductosByID(ids);
            return Ok(model);
        }
        [HttpPost]
        [Route("saveProductos")]
        public IActionResult saveProductos([FromBody] mercanciaViewModel obj)
        {
            ServiceResult model = new ServiceResult();
            if (ModelState.IsValid)
            {
                model = _maintenance.saveProductos(obj);
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("getSuplidores")]
        public IActionResult getSuplidores()
        {
            var model = _maintenance.getSuplidor(this.getQueryFilterHeader());
            return Ok(model);
        }

        [HttpGet]
        [Route("getSuplidoreByID")]
        public IActionResult getSuplidoreByID(string ids)
        {
            var model = _maintenance.getSuplidorByID(ids);
            return Ok(model);
        }
        [HttpPost]
        [Route("saveSuplidor")]
        public IActionResult saveSuplidor([FromBody] suplidorViewModel obj)
        {
            ServiceResult model = new ServiceResult();
            if (ModelState.IsValid)
            {
                model = _maintenance.saveSuplidor(obj);
            }
            return Ok(model);
        }


        [HttpGet]
        [Route("getCiudades")]
        public IActionResult getCiudades()
        {
            var model = _maintenance.getCiudades(this.getQueryFilterHeader());
            return Ok(model);
        }
        [HttpGet]
        [Route("getCiudadeByID")]
        public IActionResult getCiudadeByID(string ids)
        {
            var model = _maintenance.getCiudadeByID(ids);
            return Ok(model);
        }
        [HttpPost]
        [Route("saveCiudades")]
        public IActionResult saveCiudades([FromBody] ciudadViewModel obj)
        {
            ServiceResult model = new ServiceResult();
            if (ModelState.IsValid)
            {
                model = _maintenance.saveCiudades(obj);
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("getSectores")]
        public IActionResult getSectores()
        {
            var model = _maintenance.getSectores(this.getQueryFilterHeader());
            return Ok(model);
        }
        [HttpGet]
        [Route("getSectoresByID")]
        public IActionResult getSectoresByID(string ids)
        {
            var model = _maintenance.getSectoresByID(ids);
            return Ok(model);
        }
        [HttpPost]
        [Route("saveSectores")]
        public IActionResult saveSectores([FromBody] sectoresViewModel obj)
        {
            ServiceResult model = new ServiceResult();
            if (ModelState.IsValid)
            {
                model = _maintenance.saveSectores(obj);
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("getRegiones")]
        public IActionResult getRegiones()
        {
            var model = _maintenance.getRegiones(this.getQueryFilterHeader());
            return Ok(model);
        }
        [HttpGet]
        [Route("getRegionesByID")]
        public IActionResult getRegionesByID(string ids)
        {
            var model = _maintenance.getRegionesByID(ids);
            return Ok(model);
        }
        [HttpPost]
        [Route("saveRegiones")]
        public IActionResult saveRegiones([FromBody] regionViewModel obj)
        {
            ServiceResult model = new ServiceResult();
            if (ModelState.IsValid)
            {
                model = _maintenance.saveRegiones(obj);
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("getCategorias")]
        public IActionResult getCategorias()
        {
            var model = _maintenance.getCategorias(this.getQueryFilterHeader());
            return Ok(model);
        }
        [HttpGet]
        [Route("getCategoriaByID")]
        public IActionResult getCategoriaByID(string ids)
        {
            var model = _maintenance.getCategoriaByID(ids);
            return Ok(model);
        }
        [HttpPost]
        [Route("saveCategoria")]
        public IActionResult saveCategoria([FromBody] categoriaViewModel obj)
        {
            ServiceResult model = new ServiceResult();
            if (ModelState.IsValid)
            {
                model = _maintenance.saveCategoria(obj);
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("getZipCode")]
        public IActionResult getZipCode()
        {
            var model = _maintenance.getZipcode(this.getQueryFilterHeader());
            return Ok(model);
        }
        [HttpGet]
        [Route("getZipCodeByID")]
        public IActionResult getZipCodeByID(string ids)
        {
            var model = _maintenance.getZipcodeByID(ids);
            return Ok(model);
        }
        [HttpPost]
        [Route("saveZipCode")]
        public IActionResult saveZipCode([FromBody] zipcodeViewModel obj)
        {
            ServiceResult model = new ServiceResult();
            if (ModelState.IsValid)
            {
                model = _maintenance.saveZipcode(obj);
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("getMonedas")]
        public IActionResult getMonedas()
        {
            var model = _maintenance.getMonedas(this.getQueryFilterHeader());
            return Ok(model);
        }
        [HttpGet]
        [Route("getMonedasByID")]
        public IActionResult getMonedaByID(string ids)
        {
            var model = _maintenance.getMonedaByID(ids);
            return Ok(model);
        }
        [HttpPost]
        [Route("saveMoneda")]
        public IActionResult saveMoneda([FromBody] monedasViewModel obj)
        {
            ServiceResult model = new ServiceResult();
            if (ModelState.IsValid)
            {
                model = _maintenance.saveMoneda(obj);
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("getImpuestos")]
        public IActionResult getImpuestos()
        {
            var model = _maintenance.getImpuestos(this.getQueryFilterHeader());
            return Ok(model);
        }
        [HttpGet]
        [Route("getImpuestoByID")]
        public IActionResult getImpuestoByID(string ids)
        {
            var model = _maintenance.getImpuestoByID(ids);
            return Ok(model);
        }
        [HttpPost]
        [Route("saveImpuesto")]
        public IActionResult saveImpuesto([FromBody] impuestoViewModel obj)
        {
            ServiceResult model = new ServiceResult();
            if (ModelState.IsValid)
            {
                model = _maintenance.saveImpuesto(obj);
            }
            return Ok(model);
        }

    }
}
