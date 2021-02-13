using System;
using System.Collections.Generic;

namespace ApplicationService.ViewModels.Response {

    public class TrainResponse {

        public int Id { get; set; }
        public string Name { get; set; }
        public string CoverPage { get; set; }
        public DateTime? DtaEnd { get; set; }
        public DateTime DtaCreated { get; set; }
        public DateTime DtaUpdated { get; set; }
        public List<ExerciseResponse> Exercises { get; set; }

    }
}
