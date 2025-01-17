﻿
using System.Collections.Generic;


namespace Lab2.Models
{
    /// <summary>
    /// Модель запроса задачи
    /// </summary>
    public class Task
    {
        /// <summary>
        /// id задачи
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// имя задачи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// описание задачи
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// статус завершенности задачи
        /// </summary>
        public bool TaskState { get; set; }

        /// <summary>
        /// Идентификатор исполнителя
        /// </summary>
        public int ExecutorId { get; set; }

        /// <summary>
        /// Список тегов
        /// </summary>
        public List<Tags> Tags { get; set; }
    }
}
