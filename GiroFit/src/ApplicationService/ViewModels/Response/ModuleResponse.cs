using System;
using System.Collections.Generic;

namespace ApplicationService.ViewModels.Response {

    public class ModuleResponse {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? DtaStart { get; set; }
        public DateTime? DtaEnd { get; set; }
        public DateTime DtaCreated { get; set; }
        public DateTime DtaUpdated { get; set; }
        public List<TrainResponse> Trains { get; set; }

    }
}
