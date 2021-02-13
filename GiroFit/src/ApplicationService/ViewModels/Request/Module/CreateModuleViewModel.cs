using ApplicationService.ViewModels.Request.Train;
using System;
using System.Collections.Generic;

namespace ApplicationService.ViewModels.Request.Module {

    public class CreateModuleViewModel {

        public DateTime DtaStart { get; set; }
        public int IdUser { get; set; }
        public int IdTemplateModule { get; set; }
        public List<CreateTrainViewModel> Trains { get; set; }

    }

}
