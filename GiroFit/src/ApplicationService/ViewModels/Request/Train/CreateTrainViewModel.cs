using ApplicationService.ViewModels.Request.Exercise;
using System;
using System.Collections.Generic;

namespace ApplicationService.ViewModels.Request.Train {

    public class CreateTrainViewModel {

        public DateTime DtaStart { get; set; }
        public int IdModule { get; set; }
        public int IdTemplateTrain { get; set; }
        public List<CreateExerciseViewModel> Exercises { get; set; }

    }
}
