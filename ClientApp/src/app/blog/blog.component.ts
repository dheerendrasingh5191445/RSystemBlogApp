import { Component, OnInit } from '@angular/core';
import { BlogModel, State } from './model/blogpost.model';
import { FormArray, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { BlogService } from './service/blog.service';
import { environment } from '../../environments/environment';
import { throwError } from 'rxjs';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent implements OnInit {

  username:string = '';
  blogposts: BlogModel[] = [];
  blogForm: FormGroup;
  showloader:boolean = true;

  constructor(private fb:FormBuilder, private service: BlogService, private datePipe: DatePipe) {
    this.username = environment.username;
    this.blogForm = this.fb.group({
      blogs: this.fb.array([])
    });
    this.getData();
  }

  ngOnInit(): void {
  }

  getData(){
    this.service.getAll().subscribe(data => {
      this.blogposts = data;
      this.bindData()
      this.showloader = false;
    },(x:any)=>{ 
      this.showloader = false;
    },() => { });
  }

  bindData(){
    this.blogForm = this.fb.group({
      blogs: this.fb.array([])
    });
    this.blogposts.map(item => {
      this.blogs.push(this.createFormGroup(this.fb, item, {}));
    });
  }

  createFormGroup<T extends { [key: string]: any }>(
    formBuilder: FormBuilder,
    dataSource: T,
    validators: { [key: string]: ValidatorFn | null }
  ): FormGroup {
    // dynamic creation of form control by enumerating the object
    const config: any = {};
    Object.keys(dataSource).forEach((propertyName: string) => {
      const fieldValidators = validators[propertyName];
      const value = dataSource[propertyName];
      if (!(value instanceof Array)) {
        if (fieldValidators !== undefined) {
          config[propertyName] = [value, fieldValidators];
        } else {
          config[propertyName] = [value];
        }
      }
    });
    const group = formBuilder.group(config);
    group.get('text')?.disable();
    return group;
  }

  get blogs() : FormArray {
    return this.blogForm.get("blogs") as FormArray
  }
 
  newBlog(): FormGroup {
    return this.fb.group({
      id : new FormControl(0),
      username : new FormControl(this.username,[Validators.required]),
      datecreate : new FormControl(this.datePipe.transform(new Date(), 'MM/dd/yyyy'),[Validators.required]),
      text: new FormControl('',[Validators.required]),
      state: State.added
    })
  }
 
  addBlog() {
    this.blogs.push(this.newBlog());
  }
 
  deleteItem(i:number) {
    if(window.confirm('Are sure you want to delete this item ?')){
      this.blogs.removeAt(i);
      this.service.delete(i).subscribe(data => {
        this.getData();
      })
     }
  }
 
  onSubmit() {
     if (this.blogForm.valid) {
      var blogArr = this.blogForm.value.blogs;
      for(var element of blogArr){
        if(element.state == State.added){
          this.service.add(element).subscribe((data:any) =>{
            this.blogposts = data;
            this.bindData();
          })
        }
        if(element.state == State.updated){
          this.service.update(element).subscribe((data:any) =>{
            this.blogposts = data;
            this.bindData();
          })
        }
     }
      
    }else{
      throwError('Some Error Exist!!');
    }
  }

  updateItem(formgrp:any){
    formgrp.get('text')?.enable();
    formgrp.addControl('state', new FormControl(State.updated));

  }

}
