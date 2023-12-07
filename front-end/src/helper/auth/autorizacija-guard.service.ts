import {Injectable} from "@angular/core";
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from "@angular/router";
import {MyAuthService} from "../../app/services/MyAuthService";


@Injectable()
export class AutorizacijaGuard implements CanActivate {

  constructor(private router: Router, private myAuthService: MyAuthService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

    //nedovrseno privremeno rjesenje
      if (this.myAuthService.isLogiran()) {

        let isStudent = this.myAuthService.isStudent();

        if (isStudent)
        {
          this.router.navigate(['/auth/login']);
          return false;
        }

        return true;
      }


    // not logged in so redirect to login page with the return url
    this.router.navigate(['/auth/login'], { queryParams: { povratniUrl: state.url }});
    return false;
  }
}
