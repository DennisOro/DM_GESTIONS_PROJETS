package com.example.gestac;

import android.os.Bundle;
import android.os.Handler;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import android.widget.Switch;
import android.widget.Toast;

import constant.Constant;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import webservice.model.ListeTask;
import webservice.remote.ListeTaskService;
import webservice.remote.RetrofitClient;

public class TaskDetailActivity extends AppCompatActivity {
    private String User;
    private ListeTask Task;
    private EditText EdProj;
    private EditText EdIdTask;
    private EditText EdTask;
    private EditText EdHrsEstime;
    private EditText EdHrsCount;
    private EditText EdHrs;
    private Switch CkStatus;
    private static ListeTaskService serviceApi;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_task_detail);

        User= getIntent().getStringExtra("user");
        Task = (ListeTask)  getIntent().getSerializableExtra("task");
        Toolbar toolbar = (Toolbar) findViewById(R.id.detail_toolbar);
        setSupportActionBar(toolbar);
        toolbar.setTitle("Détail de tâches");
        toolbar.setSubtitle(getIntent().getStringExtra("titleUser"));

        EdProj = (EditText) findViewById(R.id.edProj);
        EdIdTask = (EditText) findViewById(R.id.edIdTask);
        EdTask = (EditText) findViewById(R.id.edTask);
        EdHrsEstime = (EditText) findViewById(R.id.edHrsEstime);
        EdHrsCount = (EditText) findViewById(R.id.edHrsCount);
        EdHrs = (EditText) findViewById(R.id.edHrs);
        CkStatus = (Switch) findViewById(R.id.ckStatus);

        EdProj.setText(Task.getNomProjet());
        EdIdTask.setText(Integer.toString(Task.getIdTask()));
        EdTask.setText(Task.getDescription());
        EdHrsEstime.setText(Integer.toString(Task.getNbHeuresEstime()));
        EdHrsCount.setText(Integer.toString(Task.getNbHeuresTravaillee()));

    }


    public void BtnSaveTask(View v){
        if(!validForm())
            return;
        save();
        Toast.makeText(TaskDetailActivity.this, "Les données ont été enregistrées", Toast.LENGTH_SHORT).show();
        Handler handler = new Handler();
        handler.postDelayed(new Runnable() {
            @Override
            public void run() {
                //textChanger.setText("After some delay, it changed to new text");
            }
        }, 3000);
        finish();
    }

    private boolean validForm(){
        boolean result=true;
        if (EdHrs.getText().toString().equals("") || Integer.parseInt(EdHrs.getText().toString())==0){
            Toast.makeText(TaskDetailActivity.this, "Le nombre de heures est un champ obligatoire", Toast.LENGTH_SHORT).show();
            result = false;
        }
        return result;
    }

    private void save(){
        serviceApi = RetrofitClient.getApi(Constant.mainUrl.MAIN_URL).create(ListeTaskService.class);
        int hrs = Integer.parseInt(EdHrs.getText().toString());
        int status = Integer.parseInt(Task.getStatus());
        if(CkStatus.isChecked())
            status = 8;

        Call<Void> TaskCall = serviceApi.UpdateHrsTask(User,Task.getIdTask(),hrs,status);
        TaskCall.enqueue(new Callback<Void>() {
            @Override
            public void onResponse(Call<Void> call, Response<Void> response) {

                if (response.isSuccessful()) {
                    Log.e("UpdateHrsTask","Enregistrement OK");
                }
            }
            @Override
            public void onFailure(Call<Void> call, Throwable t) {
                Log.e("ERROR: ", t.getMessage());
            }
        });
    }

}
