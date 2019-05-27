package webservice.model;
import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class ResLogin {
    @SerializedName("Connexion")
    @Expose
    private int Connexion;

    @SerializedName("Message")
    @Expose
    private String Message;

    public int getConnexion() {
        return Connexion;
    }

    public void setConnexion(int connexion) {
        this.Connexion = connexion;
    }

    public String getMessage() {
        return Message;
    }

    public void setMessage(String message) {
        this.Message = message;
    }
}