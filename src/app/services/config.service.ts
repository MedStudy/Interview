import { Injectable } from '@angular/core';

@Injectable()
export class ConfigService {

  public getGitEndpoint(): string {
    return 'https://api.github.com';
  }
}
