package com.onetouch.onetouch;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class SegundaActivity extends AppCompatActivity {

    TextView tvEmpresa;
    String pEmpresa;
    Button ventas;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_segunda);

        tvEmpresa = (TextView) findViewById(R.id.tvEmpresaSegunda);
        ventas = (Button) findViewById(R.id.bVentas);

        Intent intent = getIntent();
        Bundle b = intent.getExtras();

        if(b != null){
            pEmpresa = (String) b.get("empresa");
            tvEmpresa.setText(pEmpresa.toUpperCase());
        }

        ventas.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(SegundaActivity.this, VentasActivity.class);
                intent.putExtra("empresa", pEmpresa);
                SegundaActivity.this.startActivity(intent);
            }
        });
    }
}
