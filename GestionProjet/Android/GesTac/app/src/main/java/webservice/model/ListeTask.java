package webservice.model;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.io.Serializable;

public class ListeTask implements Serializable {
    @SerializedName("IdTask")
    @Expose
    private int IdTask;

    @SerializedName("Description")
    @Expose
    private String Description;

    @SerializedName("NomProjet")
    @Expose
    private String NomProjet;

    @SerializedName("nbHeures")
    @Expose
    private int nbHeures;

    @SerializedName("Status")
    @Expose
    private String Status;

    @SerializedName("Matricule")
    @Expose
    private String Matricule;

    @SerializedName("Login")
    @Expose
    private String Login;

    public int getIdTask() {
        return IdTask;
    }

    public void setIdTask(int idTask) {
        IdTask = idTask;
    }

    public String getDescription() {
        return Description;
    }

    public void setDescription(String description) {
        Description = description;
    }

    public String getNomProjet() {
        return NomProjet;
    }

    public void setNomProjet(String nomProjet) {
        NomProjet = nomProjet;
    }

    public int getNbHeures() {
        return nbHeures;
    }

    public void setNbHeures(int nbHeures) {
        this.nbHeures = nbHeures;
    }

    public String getStatus() {
        return Status;
    }

    public void setStatus(String status) {
        Status = status;
    }

    public String getMatricule() {
        return Matricule;
    }

    public void setMatricule(String matricule) {
        Matricule = matricule;
    }

    public String getLogin() {
        return Login;
    }

    public void setLogin(String login) {
        Login = login;
    }
}