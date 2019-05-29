package com.example.gestac;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.BaseAdapter;
import android.widget.ListView;
import android.widget.TextView;

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
    private List<ListeTask> ListeTasks;
    private String TitleUser;
    //ProgressBar myProgressBar;

    //private RetroAdapter retroAdapter;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_task_list);



        //Toast.makeText(TaskListActivity.this, "Liste de tâches",Toast.LENGTH_LONG).show();
        String usr= getIntent().getStringExtra("user");
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar_list);
        TitleUser = "(Utilisateur:"+usr+")";
        toolbar.setTitle("Liste de tâches "+TitleUser);

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
        ListeTasks = listeTasks;
        listView = findViewById(R.id.mListView);
        adapter = new ListViewAdapter(this,listeTasks);
        listView.setAdapter(adapter);

        listView.setOnItemClickListener(new AdapterView.OnItemClickListener()
        {

            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int position, long id) {
                // TODO Auto-generated method stub

                // Getting listview click value into String variable.
                ListeTask task = ListeTasks.get(position);

                Intent intent = new Intent(TaskListActivity.this, TaskDetailActivity.class);

                // Sending value to another activity using intent.
                intent.putExtra("user", TitleUser);
                intent.putExtra("task", task);

                startActivity(intent);

            }
        });
    }



    class ListViewAdapter extends BaseAdapter {
        private List<ListeTask> listeTasks;
        private Context context;
        public ListViewAdapter(Context context,List<ListeTask> listeTasks){
            this.context = context;
            this.listeTasks = listeTasks;
        }
        @Override
        public int getCount() {
            return listeTasks.size();
        }
        @Override
        public Object getItem(int pos) {
            return listeTasks.get(pos);
        }
        @Override
        public long getItemId(int pos) {
            return pos;
        }
        @Override
        public View getView(int position, View view, ViewGroup viewGroup) {
            if(view==null)
            {
                view= LayoutInflater.from(context).inflate(R.layout.task_list_content,viewGroup,false);
            }
            TextView txtIdTask = view.findViewById(R.id.idTache);
            TextView txtDescription = view.findViewById(R.id.description);
            TextView txtProjectName = view.findViewById(R.id.projectName);
            final ListeTask vListeTask= listeTasks.get(position);

            txtIdTask.setText(Integer.toString(vListeTask.getIdTask()));
            txtDescription.setText(vListeTask.getDescription());
            txtProjectName.setText(vListeTask.getNomProjet());



        /*view.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String idTask = view.
                //Toast.makeText(context, thisSpacecraft.getName(), Toast.LENGTH_SHORT).show();
            }
        });*/
            return view;
        }
    }

}
