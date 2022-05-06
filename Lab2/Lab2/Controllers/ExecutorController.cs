﻿using Lab2.Models;
using Lab2.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExecutorController : ControllerBase
    {

        private readonly IExecutorRepository _executorRepository;
        private readonly ITaskRepository _taskRepository;


        public ExecutorController(IExecutorRepository executorRepository, ITaskRepository taskRepository)
        {
            _executorRepository = executorRepository;
            _taskRepository = taskRepository;
        }

        // GET: api/<ExecutorController>
        /// <summary>
        /// Получение всех исполнителей задач
        /// </summary>
        /// <returns>All Executors</returns>
        [HttpGet]
        public ActionResult<List<Executor>> Get() => _executorRepository.GetExecutors();

        /// <summary>
        /// Получение исполнителя задачи по его индентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Executor</returns>
        // GET api/<ExecutorController>/5
        [HttpGet("{id:int}")]
        public ActionResult<Executor> Get(int id)
        {
            try
            {
                if (id < -1)
                {
                    return NotFound();
                }

                var executor = _executorRepository.GetExecutors().Single(executor => executor.ExecutorId == id);
                return executor;
            }
            catch
            {
                return Problem();
            }
        }


        /// <summary>
        /// Добавление исполнителя задачи
        /// </summary>
        /// <param name="executor">Новый исполнитель задач</param>
        // POST api/<ExecutorController>
        [HttpPost]
        public IActionResult Post([FromBody] ExecutorDto executor)
        {

            try
            {

                _executorRepository.AddExecutor(new Executor { Name = executor.Name, Surname = executor.Surname });
                return CreatedAtAction(nameof(Post), executor);
            }
            catch
            {
                return Problem();
            }
        }


        // PUT api/<ExecutorController>/5
        /// <summary>
        /// Изменение параметров исполнителя задачи по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="executor">Новый исполнитель задач</param>
        [HttpPut("{id:int}")]

        public IActionResult Put(int id, [FromBody] Executor executor)
        {

            try
            {
                _executorRepository.UpdateExecutor(id, executor);
                return Ok();
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
            catch
            {
                return Problem();
            }


        }

        /// <summary>
        /// Удаление всех исполнителей задач
        /// </summary>
        // DELETE api/<ExecutorController>/5
        [HttpDelete]

        public IActionResult Delete()
        {
            try
            {
                _executorRepository.RemoveAllExecutors();
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        /// <summary>
        /// Удаление исполнителя задачи по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _executorRepository.RemoveExecutor(id);
                return Ok();
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
            catch
            {
                return Problem();
            }
        }

    }
}
