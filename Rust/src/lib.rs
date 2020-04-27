extern crate rand;

use rand::Rng;
use std::mem::transmute;

pub struct RandomGeneratorParameters {
    min: i32,
    max: i32
}

pub struct RandomGenerator {
    rng: rand::prelude::ThreadRng,
    parameters: RandomGeneratorParameters
}

#[no_mangle]
pub extern fn create_random_generator(params: RandomGeneratorParameters) -> *mut RandomGenerator {
    unsafe { transmute(Box::new(RandomGenerator {
        rng: rand::thread_rng(),
        parameters: params
    })) }
}

#[no_mangle]
pub extern fn get_random_int(rng_ptr: *mut RandomGenerator) -> i32 {
    let rng = unsafe { &mut *rng_ptr };
    rng.rng.gen_range(rng.parameters.min, rng.parameters.max)
}

#[no_mangle]
pub extern fn destroy_random_generator(rng_ptr: *mut RandomGenerator) {
    let rng : Box<RandomGenerator> = unsafe { transmute(rng_ptr) };
}