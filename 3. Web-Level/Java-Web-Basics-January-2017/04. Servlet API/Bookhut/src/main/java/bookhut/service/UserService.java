package bookhut.service;

import bookhut.model.buildingModel.LoginModel;

public interface UserService {
    void createUser(LoginModel loginModel);

    LoginModel findByUsernameAndPassword(String username, String password);
}