package app.terminal;

import app.model.User;
import app.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import javax.jws.soap.SOAPBinding;
import java.io.File;
import java.io.FileInputStream;
import java.util.Date;

@Component
public class Terminal implements CommandLineRunner {

    @Autowired
    private UserService userService;

    @Override
    public void run(String... strings) throws Exception {
        User user = new User();
        user.setUserName("user1");
        user.setPassword("Aa#242dsa34");
        user.setEmail("user@gmail.com");
        user.setLastTimeLoggedIn(new Date());
        user.setAge(15);
        user.setIsDeleted(false);

        File picture = new File("resources/small_picture.jpg");
        byte[] pictureBytes = new byte[(int) picture.length()];
        FileInputStream fileInputStream = new FileInputStream(picture);
        fileInputStream.read(pictureBytes);
        user.setProfilePicture(pictureBytes);

        this.userService.creteUser(user);
    }
}