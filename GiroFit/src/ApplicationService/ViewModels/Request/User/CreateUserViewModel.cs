using Domain.Enumerators;

namespace ApplicationService.ViewModels.Request.User {

    public class CreateUserViewModel {

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public UserObjective Objective { get; set; }

        public string Nickname { get; set; }

        public UserSexo Sexo { get; set; }

        public UserFrenquency Frequency { get; set; }

        public UserLevel Level { get; set; }

    }
}
