package com.example.gestac;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.widget.ListView;
import android.widget.Toast;

import java.util.List;

import constant.Constant;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import webservice.model.ListeTask;
import webservice.remote.ListeTaskService;
import webservice.remote.RetrofitClient;

public class TaskListActivity extends AppCompatActivity {

    private static ListeTaskService serviceApi;
    private ListView listView;
    private ListViewAdapter adapter;
    //ProgressBar myProgressBar;

    //private RetroAdapter retroAdapter;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_task_list);



        Toast.makeText(TaskListActivity.this, "Liste de tâches",Toast.LENGTH_LONG).show();
        String usr= getIntent().getStringExtra("user");
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar_list);
        toolbar.setTitle("Liste de tâches (Utilisateur:"+usr+")");

        serviceApi = RetrofitClient.getApi(Constant.mainUrl.MAIN_URL).create(ListeTaskService.class);
        getListeTask(usr);

    }

    private void getListeTask(String usr){
        Call<List<ListeTask>> listTaskCall = serviceApi.ListeTask(usr);
        listTaskCall.enqueue(new Callback<List<ListeTask>>() {
            @Override
            public void onResponse(Call<List<ListeTask>> call, Response<List<ListeTask>> response) {
                //Log.e("onResponse", response.body().getMessage());
                //Toast.makeText(LoginActivity.this, response.body().getMessage(), Toast.LENGTH_LONG).show();
                //if (response.body().getConnexion().equals("1")){
                if (response.isSuccessful()) {
                    System.out.println(response.body());
                    Log.e("Body",response.body().toString());
                    populateListView(response.body());
                }
            }
            @Override
            public void onFailure(Call<List<ListeTask>> call, Throwable t) {
                Log.e("ERROR: ", t.getMessage());
            }
        });
    }

    private void populateListView(List<ListeTask> listeTasks) {
        listView = findViewById(R.id.mListView);
        adapter = new ListViewAdapter(this,listeTasks);
        listView.setAdapter(adapter);
    }

}
