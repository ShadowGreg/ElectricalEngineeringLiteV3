using System;
using System.ComponentModel.DataAnnotations;

namespace CoreV01.Properties {
    public abstract class DBDependence {
        public DBDependence(string ownerId = null) {
            SelfId = GetId();
            OwnerId = ownerId;
        }

        /// <summary>
        ///     идентификационный номер оборудования для БД
        /// </summary>
        public string SelfId { get; set; } = "";

        /// <summary>
        ///     идентификационный номер вышестоящего оборудования включающего экземпляр данного класса
        /// </summary>
        public string OwnerId { get; set; } = "";

        /// <summary>
        ///     Порядковый номер в шине - что бы при
        ///     восстановлении данных не менялся порядок приёмнтков
        /// </summary>
        /// TODO нужно ли это потому что в последующем включить все элементы в фидер
        public int SequentialNumber { get; set; } = 0;

        private static string GetId() {
            return Guid.NewGuid().ToString("N");
        }
    }
}