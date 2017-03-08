package bookhut.service;

import bookhut.entity.User;
import bookhut.model.buildingModel.LoginModel;
import bookhut.repository.UserRepository;
import bookhut.repository.UserRepositoryImpl;
import org.modelmapper.ModelMapper;

public class UserServiceImpl implements UserService {

    private UserRepository userRepository;
    private ModelMapper modelMapper;

    public UserServiceImpl() {
        this.userRepository = UserRepositoryImpl.getInstance();
        this.modelMapper = new ModelMapper();
    }

    @Override
    public void createUser(LoginModel loginModel) {
        User user = modelMapper.map(loginModel, User.class);
        this.userRepository.createUser(user);
    }

    @Override
    public LoginModel findByUsernameAndPassword(String username, String password) {
        User user = this.userRepository.findByUsernameAndPassword(username, password);
        ModelMapper modelMapper = new ModelMapper();
        LoginModel loginModel = null;
        if (user != null) {
            loginModel = modelMapper.map(user, LoginModel.class);
        }

        return loginModel;
    }
}