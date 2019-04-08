import {HeaderOptions} from '../../models/constants/header-options.enum';
import {AbsenceSemester} from '../../models/AbsenceSemester';

export class BasePortalComponent {
  AbsenceSemester: typeof AbsenceSemester = AbsenceSemester;
  HeaderOptions: typeof HeaderOptions = HeaderOptions;
}
