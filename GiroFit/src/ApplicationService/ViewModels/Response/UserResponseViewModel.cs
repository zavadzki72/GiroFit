using Domain.Enumerators;
using System.Collections.Generic;

namespace ApplicationService.ViewModels.Response {

    public class UserResponseViewModel {

        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }
        
        public UserObjective Objective { get; set; }

        public string Nickname { get; set; }

        public UserSexo Sexo { get; set; }

        public UserFrenquency Frequency { get; set; }
        
        public UserLevel Level { get; set; }

        public bool FlgInativo { get; set; }

        public List<ModuleResponse> Modules { get; set; }

    }
}
