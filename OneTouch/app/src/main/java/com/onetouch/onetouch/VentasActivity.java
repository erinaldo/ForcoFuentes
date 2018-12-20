package com.onetouch.onetouch;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TextView;

public class VentasActivity extends AppCompatActivity {

    TextView tvEmpresa;
    String pEmpresa;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_ventas);

        tvEmpresa = (TextView) findViewById(R.id.tvEmpresa);
        Intent intent = getIntent();
        Bundle b = intent.getExtras();

        if(b != null){
            pEmpresa = (String) b.get("empresa");
            tvEmpresa.setText(pEmpresa.toUpperCase());
        }
    }
}
