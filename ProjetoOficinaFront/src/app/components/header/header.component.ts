import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/services/shared.service';
import { Usuario } from 'src/app/models/usuario.model';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  teste : string;
  constructor(private shared: SharedService) { 
    this.shared = SharedService.getInstance();
    
    
   
  }

  ngOnInit() {
    this.teste = 'teste';
    
  }

}
