package tr.edu.ozu.mnmsrbf3d;

import android.content.Context;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class LoginActivity extends AppCompatActivity implements View.OnClickListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        Button enter = (Button)findViewById(R.id.button3);
        enter.setOnClickListener(this);
    }

    @Override
    public void onClick(View view) {
        EditText userName = (EditText)findViewById(R.id.editText2);
        Toast.makeText(this, userName.getText() + " is the player's name!!!!",
                Toast.LENGTH_LONG).show();
        Intent intent = new Intent(this, GameActivity.class);
        startActivity(intent);
    }

}
