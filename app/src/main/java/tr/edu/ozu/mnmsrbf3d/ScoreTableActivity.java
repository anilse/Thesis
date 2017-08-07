package tr.edu.ozu.mnmsrbf3d;

import android.app.Activity;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.FilterQueryProvider;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.Toast;
import android.widget.AdapterView.OnItemClickListener;

public class ScoreTableActivity extends Activity implements View.OnClickListener {

    private ScoreDatabase dbHelper;
    private SimpleCursorAdapter dataAdapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_score_table_main);
        Button deleter = (Button)findViewById(R.id.button5);

        dbHelper = new ScoreDatabase(this);
        dbHelper.open();
        deleter.setOnClickListener(this);
        //Generate ListView from SQLite Database
        displayListView();
    }

    private void displayListView() {
        Cursor cursor = dbHelper.fetchAllScores();

        // The desired columns to be bound
        String[] columns = new String[] {
                ScoreDatabase.KEY_NAME,
                ScoreDatabase.KEY_SCORE
        };

        // the XML defined views which the data will be bound to
        int[] to = new int[] {
                R.id.name,
                R.id.score,
        };

        // create the adapter using the cursor pointing to the desired data
        //as well as the layout information
        dataAdapter = new SimpleCursorAdapter(
                this, R.layout.activity_score_table,
                cursor,
                columns,
                to,
                0);

        ListView listView = (ListView) findViewById(R.id.listView1);
        // Assign adapter to ListView
        listView.setAdapter(dataAdapter);


        listView.setOnItemClickListener(new OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> listView, View view,
                                    int position, long id) {
                // Get the cursor, positioned to the corresponding row in the result set
                Cursor cursor = (Cursor) listView.getItemAtPosition(position);

                // Get the state's capital from this row in the database.
                String name =
                        cursor.getString(cursor.getColumnIndexOrThrow("name"));
                Toast.makeText(getApplicationContext(),
                        name, Toast.LENGTH_SHORT).show();

            }
        });

        EditText myFilter = (EditText) findViewById(R.id.myFilter);
        myFilter.addTextChangedListener(new TextWatcher() {

            public void afterTextChanged(Editable s) {
            }

            public void beforeTextChanged(CharSequence s, int start,
                                          int count, int after) {
            }

            public void onTextChanged(CharSequence s, int start,
                                      int before, int count) {
                dataAdapter.getFilter().filter(s.toString());
            }
        });

        dataAdapter.setFilterQueryProvider(new FilterQueryProvider() {
            public Cursor runQuery(CharSequence constraint) {
                return dbHelper.fetchScoresByName(constraint.toString());
            }
        });

    }

    @Override
    public void onClick(View view) {
        Toast.makeText(this, " Deleting all entries...",
                Toast.LENGTH_LONG).show();
        dbHelper.deleteAllScores();
        Toast.makeText(this, " Deleted!!!",
                Toast.LENGTH_LONG).show();
        Intent intent = new Intent(this, ScoreTableActivity.class);
        startActivity(intent);
    }
}
