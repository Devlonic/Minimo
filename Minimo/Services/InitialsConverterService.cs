namespace Minimo.Services {
    public static class InitialsConverterService {
        public static string GetInitials(string name) {
            var words = name.Split(' ');
            return words[0][0].ToString().ToUpper();
        }
    }
}
