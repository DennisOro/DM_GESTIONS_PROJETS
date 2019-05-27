package webservice.remote;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Query;
import webservice.model.ListeTask;

public interface ListeTaskService {
    @GET("ListeTask")
    //@Headers({"Content-Type: application/json"})
    Call<List<ListeTask>> ListeTask(@Query("userID") String username);
}
