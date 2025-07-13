using Microsoft.AspNetCore.Mvc;
using SilosApi.Dto;
using SilosApi.Services;

namespace SilosApi.Controllers;

[ApiController]
[Route("api/v1/Siloses")]
[Produces("application/json")]
[Consumes("application/json")]
public class SilosController(ISilosService silosService) : ControllerBase
{

    /// <summary>
    /// Получает список всех силосов
    /// </summary>
    /// <returns>Список силосов</returns>
    /// <response code="200">Возвращает список силосов</response>
    /// <response code="500">Произошла внутренняя ошибка сервера</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SilosDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<SilosDto>>> GetAllSilos([FromQuery]SilosFilterDto? silosFilterDto)
    {
        try
        {
            var silosList = await silosService.GetAllSilosAsync(silosFilterDto);
            return Ok(silosList);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    /// <summary>
    /// Получает информацию о силосе по ID
    /// </summary>
    /// <param name="id">Идентификатор силоса</param>
    /// <returns>Информация о силосе</returns>
    /// <response code="200">Возвращает информацию о силосе</response>
    /// <response code="404">Силос не найден</response>
    /// <response code="500">Произошла внутренняя ошибка сервера</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SilosDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<SilosDto>> GetSilosById(int id)
    {
        try
        {
            var silos = await silosService.GetSilosByIdAsync(id);
            
            if (silos == null)
            {
                return NotFound();
            }

            return Ok(silos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    /// <summary>
    /// Создает новый силос
    /// </summary>
    /// <param name="silosDto">Данные для создания силоса</param>
    /// <returns>Созданный силос</returns>
    /// <response code="201">Силос успешно создан</response>
    /// <response code="400">Некорректные входные данные</response>
    /// <response code="500">Произошла внутренняя ошибка сервера</response>
    [HttpPost]
    [ProducesResponseType(typeof(SilosDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<SilosDto>> CreateSilos([FromBody] SilosDto silosDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdSilos = await silosService.CreateSilosAsync(silosDto);
            return CreatedAtAction(nameof(GetSilosById), new { id = createdSilos.Id }, createdSilos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    /// <summary>
    /// Обновляет информацию о силосе
    /// </summary>
    /// <param name="id">Идентификатор силоса</param>
    /// <param name="silosDto">Обновленные данные силоса</param>
    /// <returns></returns>
    /// <response code="204">Информация успешно обновлена</response>
    /// <response code="400">Некорректные входные данные</response>
    /// <response code="404">Силос не найден</response>
    /// <response code="500">Произошла внутренняя ошибка сервера</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateSilos(int id, [FromBody] SilosDto silosDto)
    {
        try
        {
            if (id != silosDto.Id)
            {
                return BadRequest("ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await silosService.UpdateSilosAsync(silosDto);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    /// <summary>
    /// Удаляет силос
    /// </summary>
    /// <param name="id">Идентификатор силоса</param>
    /// <returns></returns>
    /// <response code="204">Силос успешно удален</response>
    /// <response code="404">Силос не найден</response>
    /// <response code="500">Произошла внутренняя ошибка сервера</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteSilos(int id)
    {
        try
        {
            var result = await silosService.DeleteSilosAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}