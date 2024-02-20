namespace ElectricalEngineering.Domain {
    public abstract class DbDependence(string ownerId = null) {
        /// <summary>
        ///     идентификационный номер оборудования для БД
        /// </summary>
        public string SelfId { get; set; } = GetId();

        /// <summary>
        ///     идентификационный номер вышестоящего оборудования включающего экземпляр данного класса
        /// </summary>
        public string OwnerId { get; set; } = ownerId;

        /// <summary>
        ///     Порядковый номер в шине - что бы при
        ///     восстановлении данных не менялся порядок приёмников
        /// </summary>
        /// 
        public int SequentialNumber { get; set; }

        /// <summary>
        /// Наименование оборудования по которому можно вести поиск в БД
        /// </summary>
        public string Name { get; set; }

        private static string GetId() {
            return Guid.NewGuid().ToString("N");
        }
    }
}