package webservice.model;
import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class ResLogin {
    @SerializedName("connexion")
    @Expose
    private int connexion;

    @SerializedName("message")
    @Expose
    private String message;

    public int getConnexion() {
        return connexion;
    }

    public void setConnexion(int connexion) {
        this.connexion = connexion;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }
}