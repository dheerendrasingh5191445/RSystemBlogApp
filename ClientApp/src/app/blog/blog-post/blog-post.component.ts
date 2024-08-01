import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { BlogModel } from '../model/blogpost.model';
import { FormArray, FormGroup } from '@angular/forms';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-blog-post',
  templateUrl: './blog-post.component.html',
  styleUrls: ['./blog-post.component.css']
})
export class BlogPostComponent implements OnInit {

  @Input() blogs!: FormArray<any>;
  @Input() blogForm!: FormGroup;
  @Output() deleteBlog = new EventEmitter<number>();
  @Output() updateBlog = new EventEmitter<BlogModel>();

  constructor() { }

  ngOnInit(): void {
  }

  deleteItem(id: number) {
    this.deleteBlog.emit(id);
  }

  updateItem(blog: any) {
    this.updateBlog.emit(blog);
  }
}
