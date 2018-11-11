export interface Employee {
    id: number;
    firstName: string;
    lastName: string;
    employmentDate: string;
    rate?: number;
    jobs: number[];
    fullName: string;
}