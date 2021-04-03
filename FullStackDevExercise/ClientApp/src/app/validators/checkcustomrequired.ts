import {AbstractControl, ValidatorFn} from '@angular/forms';

export function checkcustomrequired(): ValidatorFn {  
    return (control: AbstractControl): { [key: string]: any } | null =>  
        (control.value?.toString().toLowerCase() === ''  || control.value?.toString().toLowerCase() === '0' || control.value?.toString().toLowerCase() === '-1' )
            ? {checkcustomrequired: true} : null
}