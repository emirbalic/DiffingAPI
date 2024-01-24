using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using API.Util;
using API.DTOs;
using API.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class DiffController: ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public DiffController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }


        [HttpGet]
        public ActionResult GetItems()
        {
            var items = _itemRepository.GetItems();

            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(items);
            
        }
        
        [HttpGet("{id}")]
        public ActionResult GetDiffs(int id)
        {
            var item = _itemRepository.GetItem(id);

            if (item == null || item.Left == null || item.Right == null) return NotFound();

            if (item.Right.Equals(item.Left)) return Ok(new { diffResultType = "Equals" });

            if (item.Right.Length != item.Left.Length) return Ok(new { diffResultType = "SizeDoNotMatch" });

            DiffResponse diffResponse = DiffService.GetDiffResponse(item);

            return Ok(diffResponse);

        }


        [HttpPut("{id}/{sideparam}")]
        public  ActionResult Update(int id, string sideparam, UpdateItemDto itemToUpdate)
        {

            // === check if not null or valid base64
            if (itemToUpdate.Data == null || !Helper.IsBase64String(itemToUpdate.Data))
            {
                return BadRequest();
            } 
            else
            {
                // === check if already exists
                Item item = _itemRepository.GetItem(id);

                // === if does not exist, create a new one and add
                if (item == null)
                {
                    item = new Item
                    {
                        Id = id,
                        Left = sideparam == "left" ? itemToUpdate.Data : null,
                        Right = sideparam == "right" ? itemToUpdate.Data : null
                    };

                    if (_itemRepository.UpdateItem(id, item))
                    {

                        return Created("Changes saved", new { });
                    }
                    ModelState.AddModelError("", "Something went wrong updating item");
                    return StatusCode(500, ModelState);

                }
                // === if exists => update existing
                else
                {
                    //  === check what to update and update
                    if (sideparam == "left")
                    {
                        item.Left = itemToUpdate.Data;
                    }
                    else if (sideparam == "right")
                    {
                        item.Right = itemToUpdate.Data;
                    }
                    else
                    {
                        return BadRequest("Please provide correct side params in URL");
                    }

                    if (_itemRepository.UpdateItem(id, item))
                    {

                        return Created("Changes saved", new { });
                    }
                    ModelState.AddModelError("", "Something went wrong updating item");
                    return StatusCode(500, ModelState);
                }

            }
        }       
    }
}

