import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../../core/services/auth.service';
import { Role } from '../../../../authentication/enums/role.enum';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone : false,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private router : Router,private authService : AuthService) { }

  ngOnInit() {
    this.authService.login('admin@note-solutions.com','333Sherif%').subscribe({
      next : (response)=>{
        if(this.authService.currentUser?.roles.includes(Role[Role.Admin]))
        {
          this.router.navigate(['admin']);
          return;
        }

        this.router.navigate(['/']);
      },
      error:(error)=>{
        console.error(error);
      }
    });

  }

}
