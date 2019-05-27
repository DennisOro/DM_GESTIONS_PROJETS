package com.example.gestac;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.List;

import webservice.model.ListeTask;

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


        /*
        view.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Toast.makeText(context, thisSpacecraft.getName(), Toast.LENGTH_SHORT).show();
            }
        });*/
        return view;
    }
}