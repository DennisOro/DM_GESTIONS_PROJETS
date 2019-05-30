package webservice.remote;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Field;
import retrofit2.http.FormUrlEncoded;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Query;
import webservice.model.ListeTask;

public interface ListeTaskService {
    @GET("ListeTask")
    Call<List<ListeTask>> ListeTask(@Query("userID") String username);

    @FormUrlEncoded
    @POST("UpdateTaskHrs")
    Call<Void> UpdateHrsTask(@Field("userID") String username,
                                  @Field("idTask") int idTask,
                                  @Field("heures") int heures,
                                  @Field("status") int status);

}
