using System;

namespace ApplicationService.ViewModels.Response {

    public class ExerciseResponse {

        public int Id { get; set; }
        public int Frequency { get; set; }
        public int Sets { get; set; }
        public int Time { get; set; }
        public int BreakTime { get; set; }
        public bool IsWatched { get; set; }
        public DateTime DtaCreated { get; set; }
        public DateTime DtaUpdated { get; set; }

    }
}
