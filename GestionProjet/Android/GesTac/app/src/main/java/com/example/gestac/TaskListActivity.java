package com.example.gestac;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.widget.Toast;
//import android.widget.Toolbar;
import android.support.v7.widget.Toolbar;

public class TaskListActivity extends AppCompatActivity {
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_task_list);
        Toast.makeText(TaskListActivity.this, "Liste de tâches",Toast.LENGTH_LONG).show();
        String usr= getIntent().getStringExtra("user");
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar_list);
        toolbar.setTitle("Liste de tâches (Utilisateur:"+usr+")");
    }
}
