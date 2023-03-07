namespace UI.Entities {

    public class User {

        public readonly string email;
        public readonly string password;

        public User(string email, string password) {
            this.email = email;
            this.password = password;
        }

    }

}
