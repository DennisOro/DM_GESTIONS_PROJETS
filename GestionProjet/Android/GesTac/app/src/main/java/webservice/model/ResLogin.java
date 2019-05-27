package webservice.model;
import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class ResLogin {
    @SerializedName("UserID")
    @Expose
    private String UserID;

    @SerializedName("Password")
    @Expose
    private String Password;

    @SerializedName("AuthentificationValide")
    @Expose
    private boolean AuthentificationValide;

    @SerializedName("Role")
    @Expose
    private String Role;

    @SerializedName("Message")
    @Expose
    private String Message;


    public String getUserID() {
        return UserID;
    }

    public void setUserID(String userID) {
        UserID = userID;
    }

    public String getPassword() {
        return Password;
    }

    public void setPassword(String password) {
        Password = password;
    }

    public boolean isAuthentificationValide() {
        return AuthentificationValide;
    }

    public void setAuthentificationValide(boolean authentificationValide) {
        AuthentificationValide = authentificationValide;
    }

    public String getRole() {
        return Role;
    }

    public void setRole(String role) {
        Role = role;
    }

    public String getMessage() {
        return Message;
    }

    public void setMessage(String message) {
        this.Message = message;
    }
}