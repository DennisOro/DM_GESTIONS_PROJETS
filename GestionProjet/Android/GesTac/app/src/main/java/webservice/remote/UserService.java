package webservice.remote;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Query;
import webservice.model.ResLogin;

public interface UserService {
    //@GET("login.php/{username}/{password}")
    //Call login(@Path("username") String username, @Path("password") String password);
    //@GET("login.php")
    @GET("login")
    Call<ResLogin> login(@Query("username") String username, @Query("password") String password);
}
