package com.example.gestac;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.widget.CheckedTextView;
import android.widget.EditText;

import webservice.model.ListeTask;

public class TaskDetailActivity extends AppCompatActivity {
    private EditText EdProj;
    private EditText EdIdTask;
    private EditText EdTask;
    private EditText EdHrsCount;
    private EditText EdHrs;
    private CheckedTextView CkStatus;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_task_detail);

        String user= getIntent().getStringExtra("user");
        ListeTask task = (ListeTask)  getIntent().getSerializableExtra("task");
        Toolbar toolbar = (Toolbar) findViewById(R.id.detail_toolbar);
        toolbar.setTitle("Détail de tâches "+user);

        EdProj = (EditText) findViewById(R.id.edProj);
        EdIdTask = (EditText) findViewById(R.id.edIdTask);
        EdTask = (EditText) findViewById(R.id.edTask);
        EdHrsCount = (EditText) findViewById(R.id.edHrsCount);
        EdHrs = (EditText) findViewById(R.id.edHrs);
        CkStatus = (CheckedTextView) findViewById(R.id.ckStatus);

        EdProj.setText(task.getNomProjet());
        EdIdTask.setText(Integer.toString(task.getIdTask()));
        EdTask.setText(task.getDescription());
        EdHrsCount.setText(Integer.toString(task.getNbHeures()));

    }

}
