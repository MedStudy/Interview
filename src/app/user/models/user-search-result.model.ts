import {User} from './user.model';
export class UserSearchResult {
    public total_count: number;
    public incomplete_results: boolean;
    public items: User[];
}
